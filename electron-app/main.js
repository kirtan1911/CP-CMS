const { app, BrowserWindow, ipcMain, Menu } = require('electron');
const path = require('path');
const fs = require('fs');
const http = require('http');
const { spawn, exec } = require('child_process');

let mainWindow = null;
let backendProcess = null;

const API_PORT = 5116;
const API_URL = `http://localhost:${API_PORT}`;

// Locate the published backend executable
function getBackendPath() {
  const possiblePaths = [
    path.join(process.resourcesPath, 'bin', 'backend', 'NorthfieldCMS.API.exe'),
    path.join(__dirname, 'bin', 'backend', 'NorthfieldCMS.API.exe'),
    path.join(__dirname, '..', 'electron-app', 'bin', 'backend', 'NorthfieldCMS.API.exe')
  ];

  for (const p of possiblePaths) {
    if (fs.existsSync(p)) {
      return p;
    }
  }
  return null;
}

// Locate frontend directory
function getFrontendPath() {
  const possiblePaths = [
    path.join(process.resourcesPath, 'frontend', 'login.html'),
    path.join(__dirname, 'frontend', 'login.html'),
    path.join(__dirname, '..', 'frontend', 'login.html')
  ];

  for (const p of possiblePaths) {
    if (fs.existsSync(p)) {
      return p;
    }
  }
  return null;
}

// Check if backend API server is already responding
function isBackendRunning() {
  return new Promise((resolve) => {
    const req = http.get(`${API_URL}/swagger/v1/swagger.json`, (res) => {
      resolve(res.statusCode >= 200 && res.statusCode < 500);
    });
    req.on('error', () => resolve(false));
    req.setTimeout(1000, () => {
      req.destroy();
      resolve(false);
    });
  });
}

// Start the published .NET API backend process
async function launchBackend() {
  const alreadyRunning = await isBackendRunning();
  if (alreadyRunning) {
    console.log('Backend API is already running on port', API_PORT);
    return;
  }

  const backendExe = getBackendPath();
  if (!backendExe) {
    console.warn('Backend executable not found. Running in offline/frontend-only mode or expecting manual backend.');
    return;
  }

  const backendDir = path.dirname(backendExe);
  console.log('Launching ASP.NET Core Backend Executable:', backendExe);

  backendProcess = spawn(backendExe, [], {
    cwd: backendDir,
    env: { ...process.env, ASPNETCORE_URLS: API_URL },
    stdio: ['ignore', 'pipe', 'pipe'],
    windowsHide: true
  });

  backendProcess.stdout.on('data', (data) => {
    console.log(`[API Log]: ${data.toString().trim()}`);
  });

  backendProcess.stderr.on('data', (data) => {
    console.error(`[API Error]: ${data.toString().trim()}`);
  });

  backendProcess.on('exit', (code) => {
    console.log(`Backend process exited with code ${code}`);
  });

  // Poll until backend comes online (max 15s)
  let attempts = 0;
  while (attempts < 50) {
    await new Promise((r) => setTimeout(r, 300));
    attempts++;
    if (await isBackendRunning()) {
      console.log('Backend API successfully started and reachable on port', API_PORT);
      break;
    }
  }
}

function stopBackend() {
  if (backendProcess && !backendProcess.killed) {
    console.log('Shutting down backend process...');
    if (process.platform === 'win32') {
      exec(`taskkill /pid ${backendProcess.pid} /T /F`, (err) => {
        if (err) console.error('Taskkill error:', err);
      });
    } else {
      backendProcess.kill('SIGKILL');
    }
    backendProcess = null;
  }
}

function createWindow() {
  const iconPath = path.join(__dirname, 'icon.png');
  const hasIcon = fs.existsSync(iconPath);

  mainWindow = new BrowserWindow({
    width: 1400,
    height: 900,
    minWidth: 1024,
    minHeight: 700,
    title: 'Northfield College Management System (CP-CMS)',
    icon: hasIcon ? iconPath : undefined,
    show: false,
    autoHideMenuBar: false,
    webPreferences: {
      preload: path.join(__dirname, 'preload.js'),
      nodeIntegration: false,
      contextIsolation: true,
      webSecurity: false // Allows fetch to local backend API
    }
  });

  // Create Application Menu
  const menuTemplate = [
    {
      label: 'File',
      submenu: [
        {
          label: 'Reload Page',
          accelerator: 'CmdOrCtrl+R',
          click: () => mainWindow.reload()
        },
        {
          label: 'Toggle Full Screen',
          accelerator: 'F11',
          click: () => mainWindow.setFullScreen(!mainWindow.isFullScreen())
        },
        { type: 'separator' },
        {
          label: 'Exit',
          accelerator: 'Alt+F4',
          click: () => app.quit()
        }
      ]
    },
    {
      label: 'Developer',
      submenu: [
        {
          label: 'Toggle DevTools',
          accelerator: 'F12',
          click: () => mainWindow.webContents.toggleDevTools()
        },
        {
          label: 'Open Swagger API Specs',
          click: () => {
            const swaggerWin = new BrowserWindow({ width: 1024, height: 768, title: 'Swagger API Docs' });
            swaggerWin.loadURL(`${API_URL}/swagger`);
          }
        }
      ]
    },
    {
      label: 'Help',
      submenu: [
        {
          label: 'About Northfield CMS',
          click: () => {
            const { dialog } = require('electron');
            dialog.showMessageBox(mainWindow, {
              type: 'info',
              title: 'About Northfield CMS',
              message: 'Northfield College Management System (CP-CMS)\nVersion 1.0.0 (Desktop Edition)',
              detail: 'Built with ASP.NET Core (.NET 10), SQLite, Electron & Google Gemini AI Assistant.'
            });
          }
        }
      ]
    }
  ];

  const menu = Menu.buildFromTemplate(menuTemplate);
  Menu.setApplicationMenu(menu);

  const frontendLogin = getFrontendPath();
  if (frontendLogin) {
    mainWindow.loadFile(frontendLogin);
  } else {
    mainWindow.loadURL('about:blank');
  }

  mainWindow.once('ready-to-show', () => {
    mainWindow.show();
  });

  mainWindow.on('closed', () => {
    mainWindow = null;
  });
}

ipcMain.handle('get-app-version', () => app.getVersion());

app.whenReady().then(async () => {
  await launchBackend();
  createWindow();

  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) createWindow();
  });
});

app.on('window-all-closed', () => {
  stopBackend();
  if (process.platform !== 'darwin') {
    app.quit();
  }
});

app.on('will-quit', () => {
  stopBackend();
});
