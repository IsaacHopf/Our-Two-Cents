// Used for toggling edit in TransactionsGrid.
function executeCallbackOnEditMudDataGridOutsideClick(instance, callback) {
    document.addEventListener("click", e => {
        if (e.target.closest(".mud-datagrid-edit-onclick")) {
            return;
        } else {
            instance.invokeMethodAsync(callback);
        }
    });
}

// Used for adding new records in TransactionsGrid.
function executeCallbackOnEditMudDataGridEnter(instance, callback) {
    var elements = document.getElementsByClassName("mud-datagrid-edit-onclick");
    for (var i = 0; i < elements.length; i++) {
        elements[i].addEventListener("keydown", e => {
            if (e.key === "Enter") {
                instance.invokeMethodAsync(callback);
            }
        });
    }
}