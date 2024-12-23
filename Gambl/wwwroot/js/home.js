const slides = document.querySelectorAll(".slide");
        const prevButton = document.getElementById("prev-slide");
        const nextButton = document.getElementById("next-slide");
        let currentSlide = 0;

        function showSlide(index) {
            slides.forEach((slide, i) => slide.classList.toggle("active", i === index));
        }

        nextButton.addEventListener("click", () => {
            currentSlide = (currentSlide + 1) % slides.length;
            showSlide(currentSlide);
        });

        prevButton.addEventListener("click", () => {
            currentSlide = (currentSlide - 1 + slides.length) % slides.length;
            showSlide(currentSlide);
        });
        const gridWrapper = document.querySelector(".grid-wrapper");
        const prevGridButton = document.getElementById("prev-grid-slide");
        const nextGridButton = document.getElementById("next-grid-slide");

        let currentGridSlide = 0;

        function updateGridButtons() {
            prevGridButton.disabled = currentGridSlide === 0;
            nextGridButton.disabled = currentGridSlide === 1;
        }

        function showGridSlide() {
            const slideWidth = document.querySelector(".grid-slide").offsetWidth;
            gridWrapper.style.transform = `translateX(-${slideWidth * currentGridSlide
                }px)`;
            updateGridButtons();
        }

        nextGridButton.addEventListener("click", () => {
            currentGridSlide++;
            showGridSlide();
        });

        prevGridButton.addEventListener("click", () => {
            currentGridSlide--;
            showGridSlide();
        });

        updateGridButtons();