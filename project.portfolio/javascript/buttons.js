document.addEventListener('DOMContentLoaded', function() {
    var educationBtn = document.getElementById('education-btn');
    var workBtn = document.getElementById('work-btn');
    var educationContent = document.getElementById('education');
    var workContent = document.getElementById('work');
    var allButtons = document.querySelectorAll('.btn'); // Get all buttons

    // Function to remove active class from all buttons
    function removeActiveClasses() {
        allButtons.forEach(function(button) {
            button.classList.remove('btn-active');
        });
    }

    // Initially hide all content
    educationContent.style.display = 'none';
    workContent.style.display = 'none';

    educationBtn.addEventListener('click', function() {
        educationContent.style.display = 'block'; 
        workContent.style.display = 'none'; 
        removeActiveClasses();
        educationBtn.classList.add('btn-active'); 
    });

    workBtn.addEventListener('click', function() {
        workContent.style.display = 'block'; 
        educationContent.style.display = 'none'; 
        removeActiveClasses(); 
        workBtn.classList.add('btn-active'); 
    });
});
