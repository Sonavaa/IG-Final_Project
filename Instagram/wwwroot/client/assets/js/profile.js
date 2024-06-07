"use strict";
var input = document.getElementById("input");
var clickedPic = document.querySelector(".no-photo");
var shareText = document.querySelector("#share");
const modal = document.querySelector("#modal");
const overlay = document.querySelector(".overlay");
const modal_Btn = document.querySelector("#modalBtn");

shareText.addEventListener("click", (e) => {
  e.preventDefault();
  input.click();
});

clickedPic.addEventListener("click", (e) => {
  e.preventDefault();
  console.log("clicked");
  modal.classList.remove("hidden");
  overlay.classList.remove("hidden");
});

// document.body.addEventListener("onclick", (e) => {

//     e.preventDefault();
//     modal.classList.add("hidden")
//     overlay.classList.add("hidden")
// });

modal_Btn.addEventListener("click", (e) => {
  e.preventDefault();
  input.click();
});
