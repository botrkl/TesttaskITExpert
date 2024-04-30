class CategoryManager {
    constructor() {
        this.selectedCategoriesDiv = document.getElementById("selected-categories");
        this.addCategoriesDiv = document.querySelector(".categories");

        this.selectedCategoriesDiv.addEventListener("click", this.handleCategoryClick.bind(this));
        this.addCategoriesDiv.addEventListener("click", this.handleCategoryClick.bind(this));

        document.getElementById("submit-button").addEventListener("click", this.handleSubmit.bind(this));
    }

    handleCategoryClick(event) {
        var targetCategory = event.target;
        if (targetCategory.tagName === "A") {
            if (targetCategory.parentElement === this.selectedCategoriesDiv) {
                this.addCategoriesDiv.appendChild(targetCategory);
            } else {
                this.selectedCategoriesDiv.appendChild(targetCategory);
            }
        }
    }

    handleSubmit() {
        var selectedCategoryLinks = this.selectedCategoriesDiv.querySelectorAll("a");
        var selectedCategories = [];

        selectedCategoryLinks.forEach(function (link) {
            selectedCategories.push(link.getAttribute("id"));
        });

        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/film/AddCategoryToFilm/@Model.Id', true);
        xhr.setRequestHeader('Content-Type', 'application/json');

        xhr.send(JSON.stringify(selectedCategories));
    }
}

document.addEventListener("DOMContentLoaded", function () {
    new CategoryManager();
});
