class CategorySelector {
    constructor(categories, selectedCategories) {
        this.categories = categories;
        this.selectedCategories = selectedCategories;
        this.init();
    }

    init() {
        // Додавання категорій до випадаючого списку
        const selectElement = document.createElement('select');
        selectElement.multiple = true;
        this.categories.forEach(category => {
            const optionElement = document.createElement('option');
            optionElement.value = category.id;
            optionElement.textContent = category.name;
            if (this.selectedCategories.includes(category.id)) {
                optionElement.selected = true;
            }
            selectElement.appendChild(optionElement);
        });

        // Додавання обробників подій
        selectElement.addEventListener('change', this.handleCategoryChange.bind(this));

        // Очищення контейнера та додавання випадаючого списку
        const selectedCategoriesContainer = document.getElementById('selected-categories');
        selectedCategoriesContainer.innerHTML = '';
        selectedCategoriesContainer.appendChild(selectElement);
    }

    handleCategoryChange(event) {
        const selectedOptions = event.target.selectedOptions;
        const selectedCategoryIds = Array.from(selectedOptions).map(option => parseInt(option.value));
        this.selectedCategories = selectedCategoryIds;
    }
}

