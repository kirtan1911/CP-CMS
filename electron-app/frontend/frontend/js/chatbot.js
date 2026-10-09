/* ============================================================
   NORTHFIELD CMS — GEMINI AI CHATBOT WIDGET
   Floating glassmorphism chatbot UI powered by ASP.NET Web API
   and Google Gemini API backend integration.
============================================================ */

(function () {
  // Inject Chatbot HTML into DOM once loaded
  document.addEventListener('DOMContentLoaded', () => {
    if (document.getElementById('gemini-chatbot-container')) return;

    const botHtml = `
      <!-- GEMINI CHATBOT WIDGET CONTAINER -->
      <div id="gemini-chatbot-container" style="position: fixed; bottom: 24px; right: 24px; z-index: 9999; font-family: 'Inter', sans-serif;">
        <!-- CHATBOT LAUNCHER BUTTON -->
        <button id="chatbot-launcher-btn" onclick="toggleChatbot()" style="
          width: 54px; height: 54px; border-radius: 50%;
          background: linear-gradient(135deg, #7c3aed 0%, #22d3ee 100%);
          border: 1px solid rgba(255, 255, 255, 0.2);
          color: #fff; font-size: 22px; cursor: pointer;
          box-shadow: 0 8px 32px rgba(124, 58, 237, 0.45);
          display: grid; place-items: center; transition: transform 0.2s cubic-bezier(0.34, 1.56, 0.64, 1);
        ">
          <i class="bi bi-robot" id="chatbot-launcher-icon"></i>
        </button>

        <!-- CHATBOT WINDOW -->
        <div id="chatbot-window" style="
          display: none; position: absolute; bottom: 68px; right: 0;
          width: min(380px, calc(100vw - 32px)); height: 520px;
          background: rgba(15, 15, 17, 0.95); backdrop-filter: blur(20px);
          border: 1px solid rgba(255, 255, 255, 0.12);
          border-radius: 18px; box-shadow: 0 24px 60px rgba(0, 0, 0, 0.6);
          flex-direction: column; overflow: hidden;
          transition: all 0.25s ease;
        ">
          <!-- HEADER -->
          <div style="
            padding: 14px 18px; background: rgba(255, 255, 255, 0.03);
            border-bottom: 1px solid rgba(255, 255, 255, 0.08);
            display: flex; align-items: center; justify-content: space-between;
          ">
            <div style="display: flex; align-items: center; gap: 10px;">
              <div style="
                width: 34px; height: 34px; border-radius: 10px;
                background: rgba(124, 58, 237, 0.2); color: #22d3ee;
                display: grid; place-items: center; font-size: 17px;
                border: 1px solid rgba(34, 211, 238, 0.3);
              ">
                <i class="bi bi-cpu"></i>
              </div>
              <div>
                <div style="font-size: 13.5px; font-weight: 700; color: #f4f4f5; line-height: 1.2;">Gemini Assistant</div>
                <div style="font-size: 10.5px; color: #22c55e; display: flex; align-items: center; gap: 4px;">
                  <span style="width: 6px; height: 6px; border-radius: 50%; background: #22c55e;"></span> Online — ASP.NET + Gemini AI
                </div>
              </div>
            </div>
            <button onclick="toggleChatbot()" style="background: none; border: none; color: #a1a1aa; font-size: 18px; cursor: pointer; padding: 4px;">
              <i class="bi bi-x-lg"></i>
            </button>
          </div>

          <!-- MESSAGES BODY -->
          <div id="chatbot-messages" style="
            flex: 1; padding: 16px; overflow-y: auto;
            display: flex; flex-direction: column; gap: 12px;
            scrollbar-width: thin; scrollbar-color: rgba(255,255,255,0.1) transparent;
          ">
            <!-- WELCOME MESSAGE -->
            <div style="display: flex; gap: 10px; align-items: flex-start;">
              <div style="
                width: 28px; height: 28px; border-radius: 8px;
                background: rgba(124, 58, 237, 0.2); color: #c4b5fd;
                display: grid; place-items: center; font-size: 13px; flex-shrink: 0;
              "><i class="bi bi-robot"></i></div>
              <div style="
                background: rgba(255, 255, 255, 0.05); border: 1px solid rgba(255, 255, 255, 0.08);
                border-radius: 12px; padding: 10px 14px; color: #f4f4f5; font-size: 12.5px; line-height: 1.5; max-width: 85%;
              ">
                Hello! 👋 I am your Northfield CMS AI Assistant powered by Google Gemini. Ask me about exam schedules, attendance, fees, courses, or campus information!
              </div>
            </div>
          </div>

          <!-- SUGGESTION CHIPS -->
          <div style="padding: 6px 14px 8px; display: flex; gap: 6px; overflow-x: auto; flex-shrink: 0;">
            <button onclick="sendQuickPrompt('When are mid-term exams?')" style="
              background: rgba(124,58,237,0.15); border: 1px solid rgba(124,58,237,0.3);
              color: #c4b5fd; font-size: 11px; padding: 4px 10px; border-radius: 20px;
              white-space: nowrap; cursor: pointer; transition: background 0.15s;
            ">📅 Exam Schedule</button>
            <button onclick="sendQuickPrompt('Check my attendance percentage')" style="
              background: rgba(34,211,238,0.12); border: 1px solid rgba(34,211,238,0.3);
              color: #22d3ee; font-size: 11px; padding: 4px 10px; border-radius: 20px;
              white-space: nowrap; cursor: pointer; transition: background 0.15s;
            ">📊 Attendance Status</button>
            <button onclick="sendQuickPrompt('How do I pay my tuition fee?')" style="
              background: rgba(34,197,94,0.12); border: 1px solid rgba(34,197,94,0.3);
              color: #4ade80; font-size: 11px; padding: 4px 10px; border-radius: 20px;
              white-space: nowrap; cursor: pointer; transition: background 0.15s;
            ">💳 Fee Payment</button>
          </div>

          <!-- INPUT AREA -->
          <form onsubmit="handleChatSubmit(event)" style="
            padding: 10px 14px; background: rgba(255, 255, 255, 0.02);
            border-top: 1px solid rgba(255, 255, 255, 0.08);
            display: flex; gap: 8px; align-items: center;
          ">
            <input id="chatbot-input" type="text" placeholder="Ask Gemini AI..." style="
              flex: 1; background: rgba(255, 255, 255, 0.06); border: 1px solid rgba(255, 255, 255, 0.12);
              border-radius: 10px; padding: 9px 12px; color: #fff; font-size: 12.5px; outline: none;
            " />
            <button type="submit" style="
              width: 36px; height: 36px; border-radius: 10px;
              background: #7c3aed; border: none; color: #fff;
              display: grid; place-items: center; font-size: 15px; cursor: pointer; flex-shrink: 0;
            ">
              <i class="bi bi-send-fill"></i>
            </button>
          </form>
        </div>
      </div>
    `;

    document.body.insertAdjacentHTML('beforeend', botHtml);
  });
})();

// Toggle Chatbot window
function toggleChatbot() {
  const win = document.getElementById('chatbot-window');
  const btnIcon = document.getElementById('chatbot-launcher-icon');
  if (!win) return;

  const isHidden = win.style.display === 'none' || win.style.display === '';
  win.style.display = isHidden ? 'flex' : 'none';
  if (btnIcon) {
    btnIcon.className = isHidden ? 'bi bi-chevron-down' : 'bi bi-robot';
  }
}

// Send quick prompt from chips
function sendQuickPrompt(text) {
  const input = document.getElementById('chatbot-input');
  if (input) {
    input.value = text;
    handleChatSubmit(new Event('submit'));
  }
}

// Handle Chat Submission
async function handleChatSubmit(e) {
  if (e) e.preventDefault();
  const input = document.getElementById('chatbot-input');
  const msgContainer = document.getElementById('chatbot-messages');
  if (!input || !msgContainer) return;

  const text = input.value.trim();
  if (!text) return;

  // Render User Message
  const userMsgHtml = `
    <div style="display: flex; gap: 8px; align-items: flex-start; justify-content: flex-end;">
      <div style="
        background: #7c3aed; color: #fff; border-radius: 12px;
        padding: 9px 13px; font-size: 12.5px; line-height: 1.5; max-width: 85%;
      ">${escapeHtml(text)}</div>
    </div>
  `;
  msgContainer.insertAdjacentHTML('beforeend', userMsgHtml);
  input.value = '';
  msgContainer.scrollTop = msgContainer.scrollHeight;

  // Render Typing Indicator
  const typingId = 'typing-' + Date.now();
  const typingHtml = `
    <div id="${typingId}" style="display: flex; gap: 10px; align-items: flex-start;">
      <div style="
        width: 28px; height: 28px; border-radius: 8px;
        background: rgba(124, 58, 237, 0.2); color: #c4b5fd;
        display: grid; place-items: center; font-size: 13px; flex-shrink: 0;
      "><i class="bi bi-robot"></i></div>
      <div style="
        background: rgba(255, 255, 255, 0.05); border: 1px solid rgba(255, 255, 255, 0.08);
        border-radius: 12px; padding: 10px 14px; color: #a1a1aa; font-size: 12px;
      ">
        <i class="bi bi-three-dots-vertical" style="animation: pulse 1s infinite;"></i> Gemini is thinking...
      </div>
    </div>
  `;
  msgContainer.insertAdjacentHTML('beforeend', typingHtml);
  msgContainer.scrollTop = msgContainer.scrollHeight;

  // Call Web API Gemini endpoint
  const userContext = API.getUser() ? `Role: ${API.getUser().role}, Name: ${API.getUser().name}` : 'Guest User';
  const res = await API.sendChatMessage(text, userContext);

  // Remove typing indicator
  const typingEl = document.getElementById(typingId);
  if (typingEl) typingEl.remove();

  const botReply = (res && res.data && res.data.reply) 
    ? res.data.reply 
    : "I am Northfield CMS AI Assistant. How can I help you with your college records or course inquiries today?";

  // Render Bot Response
  const botMsgHtml = `
    <div style="display: flex; gap: 10px; align-items: flex-start;">
      <div style="
        width: 28px; height: 28px; border-radius: 8px;
        background: rgba(124, 58, 237, 0.2); color: #c4b5fd;
        display: grid; place-items: center; font-size: 13px; flex-shrink: 0;
      "><i class="bi bi-robot"></i></div>
      <div style="
        background: rgba(255, 255, 255, 0.05); border: 1px solid rgba(255, 255, 255, 0.08);
        border-radius: 12px; padding: 10px 14px; color: #f4f4f5; font-size: 12.5px; line-height: 1.55; max-width: 85%;
      ">
        ${escapeHtml(botReply).replace(/\n/g, '<br>')}
      </div>
    </div>
  `;
  msgContainer.insertAdjacentHTML('beforeend', botMsgHtml);
  msgContainer.scrollTop = msgContainer.scrollHeight;
}

function escapeHtml(str) {
  return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;');
}
