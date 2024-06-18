"use strict";

var input = document.querySelector("#input");
var change_photo = document.querySelector("#change-photo");
const pp_photo = document.querySelector(".about-profile .left img");

change_photo.addEventListener("click", (e) => {
    e.preventDefault();
    console.log("clicked");
    input.click();
});

if (input != undefined) {
    input.addEventListener("change", (e) => {
        var selectedPPFile = e.target.files[0];

        if (selectedPPFile) {
            var reader = new FileReader();

            reader.onload = function (e) {
                pp_photo.src = e.target.result;
            };

            reader.readAsDataURL(selectedPPFile);
        } else {
            alert("Lütfen bir dosya seçin.");
        }

        if (selectedPPFile != null) {
            console.log("Selected File Name: ", selectedPPFile.name);
            console.log("Selected File Size: ", selectedPPFile.size, " bytes");
        }
        else {
            menu_Modal.style.display = "none";
        }
    });
}

