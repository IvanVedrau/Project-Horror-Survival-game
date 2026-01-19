document.addEventListener('DOMContentLoaded', function() {
    const btnDarkMode = document.querySelector(".dark-mode-btn");

    // Function to check and apply dark mode settings
    function applyDarkModeSettings() {
        const isDarkMode = localStorage.getItem('darkMode') === 'dark';
        document.body.classList.toggle('dark', isDarkMode);
        btnDarkMode.classList.toggle('dark-mode-btn--active', isDarkMode);
    }

    // Event listener for system theme change
    window.matchMedia("(prefers-color-scheme: dark)").addEventListener("change", (event) => {
        localStorage.setItem("darkMode", event.matches ? "dark" : "light");
        applyDarkModeSettings();
    });

    // Click event for toggling dark mode
    btnDarkMode.onclick = function() {
        const isDarkMode = document.body.classList.contains('dark');
        localStorage.setItem('darkMode', isDarkMode ? 'light' : 'dark');
        applyDarkModeSettings();
    };

    // Initialize dark mode based on saved preference or system preference
    if (localStorage.getItem('darkMode') === null) {
        const prefersDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
        localStorage.setItem('darkMode', prefersDark ? 'dark' : 'light');
    }
    applyDarkModeSettings();
});
