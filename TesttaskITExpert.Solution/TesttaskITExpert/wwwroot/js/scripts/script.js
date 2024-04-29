document.addEventListener('DOMContentLoaded', function () {
    const selectedCategories = []; // Массив для хранения выбранных категорий

    // Функция для добавления выбранной категории в блок
    function addCategory(category) {
        const categoryElement = document.createElement('div');
        categoryElement.classList.add('category');
        categoryElement.textContent = category;
        categoryElement.dataset.category = category;
        categoryElement.addEventListener('click', function () {
            const index = selectedCategories.indexOf(category);
            if (index !== -1) {
                selectedCategories.splice(index, 1);
                categoryElement.remove();
            }
        });
        document.getElementById('selected-categories').appendChild(categoryElement);
        selectedCategories.push(category);
    }

    // Отобразить все категории из ViewBag.Categories
    const categories = @Html.Raw(Json.Serialize(ViewBag.Categories));
    categories.forEach(category => {
        addCategory(category);
    });

    // Обработчик нажатия на кнопку "Add Category"
    document.getElementById('add-category-button').addEventListener('click', function () {
        console.log(1);
    });

    // Обработчик нажатия на кнопку "Submit"
    document.getElementById('submit-button').addEventListener('click', function () {
        // Отправляем выбранные категории на сервер
        console.log('Selected categories:', selectedCategories);
        // Здесь можно добавить код для отправки категорий на сервер
    });
});
