"use strict";

var input = document.querySelector("#input");
var change_photo = document.querySelector("#change-photo");
const pp_photo = document.querySelector(".about-profile .left img");

change_photo.addEventListener("click", (e) => {
  e.preventDefault();
  console.log("clicked");
  input.click();
});


input.addEventListener("change", (e) => {
  var selectedPPFile = e.target.files[0]; 

  if (selectedPPFile != null) { 
    console.log("Selected File Name: ", selectedPPFile.name);
    console.log("Selected File Size: ", selectedPPFile.size, " bytes");

    let pp_file_src = pp_photo.src;
    let new_pp_file_src =
      pp_file_src.substring(0, pp_file_src.lastIndexOf("/") + 1) +
      selectedPPFile.name;
    new_pp_file_src = new_pp_file_src.replace("http://127.0.0.1:5500", ".");
    pp_photo.src = new_pp_file_src;
    console.log("New File Src: ", new_pp_file_src);
  } else {
    menu_Modal.style.display = "none";
  }
});
