let ascending = true;

function toggleSort() {
    ascending = !ascending;

    const rows = document.querySelectorAll('.table tbody tr');

    const rowsArray = Array.from(rows);

    rowsArray.sort((rowA, rowB) => {
        const dateA = new Date(rowA.cells[2].innerText);
        const dateB = new Date(rowB.cells[2].innerText);

        if (ascending) {
            return dateA - dateB;
        } else {
            return dateB - dateA;
        }
    });

    const tableBody = document.querySelector('.table tbody');
    tableBody.innerHTML = '';

    rowsArray.forEach(row => {
        tableBody.appendChild(row);
    });

    const sortButton = document.getElementById('sortButton');
    sortButton.textContent = `Sort by Release Date (${ascending ? 'ascending' : 'descending'})`;
}
