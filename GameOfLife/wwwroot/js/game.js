document.addEventListener('DOMContentLoaded', function () {
    const nextGenerationBtn = document.getElementById('nextGenerationBtn');
    const resetBtn = document.getElementById('resetBtn');
    let intervalId;

    nextGenerationBtn.addEventListener('click', function () {
        fetch('Game/NextGeneration', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
            },
        })
            .then(response => response.text())
            .then(html => {
                document.getElementById('gridContainer').innerHTML = html;
            })
            .catch(error => console.error('Error:', error));
    });

    resetBtn.addEventListener('click', function () {
        fetch('/Game/Reset', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded',
            },
        })
            .then(response => response.text())
            .then(html => {
                console.log(html);
                document.getElementById('gridContainer').innerHTML = html;
            })
            .catch(error => console.error('Error:', error));
    });

    
    const autoAdvanceCheckbox = document.getElementById('autoAdvance');
    autoAdvanceCheckbox.addEventListener('change', function () {
        if (this.checked) {
            intervalId = setInterval(() => {
                fetch('Game/NextGeneration', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded',
                    },
                })
                    .then(response => response.text())
                    .then(html => {
                        document.getElementById('gridContainer').innerHTML = html;
                    })
                    .catch(error => console.error('Error:', error));
            }, 1000);
        } else {
            clearInterval(intervalId);
        }
    });
});
