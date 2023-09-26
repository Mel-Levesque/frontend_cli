document.addEventListener('DOMContentLoaded', function () {
    // Get a reference to the button element by its ID
    const createProjectButton = document.getElementById('createProjectButton');

    // Add a click event listener to the button
    createProjectButton.addEventListener('click', createNewProj);

    function createNewProj() {
        // TODO: call CLI command
        alert("Créer un nouveau projet");
        document.location.href="../view/newProject.html";
    }
});
