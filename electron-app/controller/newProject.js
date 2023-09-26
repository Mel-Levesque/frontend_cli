const { exec } = require('child_process');

document.addEventListener('DOMContentLoaded', function () {
    // Get a reference to the button element by its ID
    const backBtn = document.getElementById('back');
    const createProjectBtn = document.getElementById('createProject');

    // Add a click event listener to the button
    backBtn.addEventListener('click', goBack);
    createProjectBtn.addEventListener('click', createProject);

    function goBack() {
        document.location.href="../view/index.html";
    }

    function createProject(){
        //get form infos 
        const projectName = document.getElementById('projectName').value;
        const projectDesc = document.getElementById('projectDesc').value;
        //check info
        if(projectName != undefined && projectName != ""){
            if(projectDesc != undefined && projectDesc != ""){
                //replace all spaces by unerscore
                const name = projectName.replace(/\s+/g, '_');
                if(name.charAt(name.length -1) === "_"){
                    name.slice(0, -1)
                }
                //CLI command
                console.log("ça fonctionne")
                CLICommand(projectName, projectDesc);
            }
        }
        
    }

    function CLICommand(projectName, projectDesc){

        const command = "mjj "+projectName+ " "+projectDesc;

        exec(command, (error, stdout, stderr) => {
        if (error) {
            console.error(`Error executing ${command}: ${error.message}`);
            return;
        }

        console.log(`Command output:\n${stdout}`);
        if (stderr) {
            console.error(`Command error:\n${stderr}`);
        }
        });
    }
});