"use strict";
const high_volume = document.querySelector(".fa-volume-high");
const play_btn = document.querySelector(".fa-play");
const like_btn = document.querySelector(".fa-regular");
const message_input = document.querySelector("#msg-input");
const share_btn = document.querySelector(".fa-paper-plane");
const close_btn = document.querySelector("x");

high_volume.addEventListener("click", function (e) {
  if (high_volume.classList.contains("fa-volume-high")) {
    high_volume.classList.remove("fa-volume-high");
    high_volume.classList.add("fa-volume-xmark");
  } else {
    high_volume.classList.remove("fa-volume-xmark");
    high_volume.classList.add("fa-volume-high");
  }
});

play_btn.addEventListener("click", function (e) {
  if (play_btn.classList.contains("fa-play")) {
    play_btn.classList.remove("fa-play");
    play_btn.classList.add("fa-pause");
  } else {
    play_btn.classList.remove("fa-pause");
    play_btn.classList.add("fa-play");
  }
});

like_btn.addEventListener("click", function (e) {
  if (like_btn.classList.contains("fa-regular")) {
    like_btn.classList.remove("fa-regular");
    like_btn.classList.add("fa-solid");
    like_btn.style.color = "red";
  } else {
    like_btn.classList.remove("fa-solid");
    like_btn.classList.add("fa-regular");
    like_btn.style.color = "white";
  }
});

message_input.addEventListener("click", function () {
  like_btn.style.display = "none";
  share_btn.style.display = "none";
  message_input.style.marginRight = "15px";
});

close_btn.addEventListener("click", function (e) {
  e.preventDefault();
});


document.getElementById('fileInput').addEventListener('change', function(event) {
    const file = event.target.files[0];
    if (file) {
        const videoURL = URL.createObjectURL(file);
        const videoPlayer = document.getElementById('videoPlayer');
        const videoSource = document.getElementById('videoSource');

        videoSource.src = videoURL;
        videoPlayer.load();
    }
});