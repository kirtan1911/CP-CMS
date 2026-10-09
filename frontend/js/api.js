/* ============================================================
   NORTHFIELD CMS — AJAX API CLIENT & JWT AUTHENTICATION
   Handles Web API requests, JWT token headers, error handling,
   and dynamic data binding for Admin, Faculty, and Student panels.
============================================================ */

const API_BASE = 'http://localhost:5116/api';

const API = {
  // ── TOKEN & AUTH HELPERS ──
  getToken: () => localStorage.getItem('cms_jwt_token') || '',
  setToken: (token) => localStorage.setItem('cms_jwt_token', token),
  removeToken: () => localStorage.removeItem('cms_jwt_token'),
  getUser: () => {
    try { return JSON.parse(localStorage.getItem('cms_user_info')) || null; }
    catch { return null; }
  },
  setUser: (user) => localStorage.setItem('cms_user_info', JSON.stringify(user)),
  removeUser: () => localStorage.removeItem('cms_user_info'),

  // ── GENERIC AJAX REQUEST HANDLER ──
  request: async (endpoint, method = 'GET', data = null) => {
    const headers = {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    };

    const token = API.getToken();
    if (token) {
      headers['Authorization'] = `Bearer ${token}`;
    }

    const config = {
      method,
      headers
    };

    if (data && (method === 'POST' || method === 'PUT' || method === 'PATCH')) {
      config.body = JSON.stringify(data);
    }

    try {
      const response = await fetch(`${API_BASE}${endpoint}`, config);
      if (response.status === 401) {
        console.warn('Unauthorized request. Token may be expired.');
      }
      const json = await response.json();
      return { ok: response.ok, status: response.status, data: json };
    } catch (err) {
      console.warn(`AJAX call to ${endpoint} failed or offline. Using fallback cache.`, err);
      return { ok: false, status: 0, error: err.message };
    }
  },

  // ── AUTHENTICATION API CALLS ──
  login: async (email, password) => {
    const res = await API.request('/auth/login', 'POST', { email, password });
    if (res.ok && res.data && res.data.token) {
      API.setToken(res.data.token);
      API.setUser({
        email: res.data.email,
        name: res.data.name,
        role: res.data.role,
        department: res.data.department,
        initials: res.data.initials
      });
    }
    return res;
  },

  register: async (name, email, role, department, password) => {
    const res = await API.request('/auth/register', 'POST', { name, email, role, department, password });
    if (res.ok && res.data && res.data.token) {
      API.setToken(res.data.token);
      API.setUser({
        email: res.data.email,
        name: res.data.name,
        role: res.data.role,
        department: res.data.department,
        initials: res.data.initials
      });
    }
    return res;
  },

  getCurrentUser: async () => {
    return await API.request('/auth/me', 'GET');
  },

  // ── FORGOT PASSWORD & OTP API CALLS ──
  sendOtp: async (email) => {
    return await API.request('/auth/send-otp', 'POST', { email });
  },

  verifyOtp: async (email, otpCode) => {
    return await API.request('/auth/verify-otp', 'POST', { email, otpCode });
  },

  resetPassword: async (email, otpCode, newPassword, confirmPassword) => {
    return await API.request('/auth/reset-password', 'POST', { email, otpCode, newPassword, confirmPassword });
  },

  resendOtp: async (email) => {
    return await API.request('/auth/resend-otp', 'POST', { email });
  },

  // ── ENTITY API CALLS (AJAX) ──
  getUsers: async () => await API.request('/users'),
  createUser: async (userObj) => await API.request('/users', 'POST', userObj),

  getFaculty: async () => await API.request('/faculty'),
  createFaculty: async (facObj) => await API.request('/faculty', 'POST', facObj),

  getStudents: async () => await API.request('/students'),
  createStudent: async (stuObj) => await API.request('/students', 'POST', stuObj),

  getCourses: async () => await API.request('/courses'),
  createCourse: async (courseObj) => await API.request('/courses', 'POST', courseObj),

  getDepartments: async () => await API.request('/departments'),
  createDepartment: async (deptObj) => await API.request('/departments', 'POST', deptObj),

  getExams: async () => await API.request('/exams'),
  createExam: async (examObj) => await API.request('/exams', 'POST', examObj),

  getMarks: async () => await API.request('/marks'),

  getFees: async () => await API.request('/fees'),

  getNotifications: async () => await API.request('/notifications'),

  getMaterials: async () => await API.request('/materials'),

  // ── GEMINI CHATBOT API CALL ──
  sendChatMessage: async (message, context = 'Student Portal') => {
    return await API.request('/chatbot/chat', 'POST', { message, context });
  },

  // ── DYNAMIC BACKEND DATA LOADER ──
  loadDynamicData: async (page) => {
    if (typeof rows === 'undefined') return;

    if (page === 'users') {
      const res = await API.getUsers();
      if (res.ok && Array.isArray(res.data)) {
        rows.sysusers = res.data.map(u => [u.code, u.name, u.email, u.role, u.status, u.createdAt]);
      }
    } else if (page === 'faculty') {
      const res = await API.getFaculty();
      if (res.ok && Array.isArray(res.data)) {
        rows.faculty = res.data.map(f => [f.code, f.name, f.email, f.department, f.specialization, f.experience, f.status]);
      }
    } else if (page === 'students') {
      const res = await API.getStudents();
      if (res.ok && Array.isArray(res.data)) {
        rows.students = res.data.map(s => [s.code, s.name, s.email, s.department, s.semester, s.attendance, s.status]);
      }
    } else if (page === 'courses') {
      const res = await API.getCourses();
      if (res.ok && Array.isArray(res.data)) {
        rows.courses = res.data.map(c => [c.code, c.name, c.department, c.credits.toString(), c.faculty, c.semester, c.status]);
      }
    } else if (page === 'departments') {
      const res = await API.getDepartments();
      if (res.ok && Array.isArray(res.data)) {
        rows.departments = res.data.map(d => [d.name, d.head, d.courses.toString(), d.students.toString(), d.status]);
      }
    } else if (page === 'exams') {
      const res = await API.getExams();
      if (res.ok && Array.isArray(res.data)) {
        rows.exams = res.data.map(e => [e.examName, e.subject, e.course, e.date, e.time, e.duration, e.maxMarks.toString(), e.status]);
      }
    } else if (page === 'fees') {
      const res = await API.getFees();
      if (res.ok && Array.isArray(res.data)) {
        rows.fees = res.data.map(f => [f.studentName, f.course, f.totalFees, f.paid, f.pending, f.dueDate, f.status]);
      }
    } else if (page === 'notifications') {
      const res = await API.getNotifications();
      if (res.ok && Array.isArray(res.data)) {
        rows.notifications = res.data.map(n => ({
          title: n.title,
          body: n.body,
          time: n.time,
          unread: n.unread,
          icon: n.icon,
          bg: n.bg,
          ic: n.ic
        }));
      }
    }

    // Trigger UI refresh with dynamic backend data
    const contentEl = document.getElementById('content');
    if (contentEl && typeof pageContent === 'function') {
      contentEl.innerHTML = pageContent();
    }
  }
};

// Automatically fetch dynamic data & check auth guard on DOM Content Loaded
document.addEventListener('DOMContentLoaded', () => {
  const isLoginPage = window.location.pathname.toLowerCase().endsWith('login.html');
  const token = API.getToken();
  if (!token && !isLoginPage) {
    window.location.href = 'login.html';
    return;
  }
  if (typeof currentPage !== 'undefined') {
    API.loadDynamicData(currentPage);
  }
});
