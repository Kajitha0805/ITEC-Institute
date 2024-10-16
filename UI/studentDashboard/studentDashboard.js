let topBarMenu = document.getElementById("topBarMenu");
let topBar = document.getElementById("topBar");
let offCanvas = document.getElementById("offCanvas");
let mainBody = document.getElementById("mainBody");

topBarMenu.onclick = function(){
    topBarMenu.style.display = "none";
    topBar.style.width = "80%";
    offCanvas.style.display = "block";
    mainBody.style.width = "80%";
}

let offMenu = document.getElementById("offMenu");

offMenu.onclick = function(){
    offCanvas.style.display = "none";
    topBar.style.width = "100%";
    mainBody.style.width = "100%";
    topBarMenu.style.display = "block";
}