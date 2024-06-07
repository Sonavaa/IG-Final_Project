'use strict';
const x_btn = document.querySelector(".fa-x");
const switch_modal = document.querySelector(".switchModal")
const open_switch_modal = document.querySelector(".open-switch-modal")
const new_message_modal = document.querySelector(".new-message-modal")
const send_message_btn = document.querySelector("#send_msg_btn")
const x = document.querySelector(".fa-times")

open_switch_modal.addEventListener("click", function() {
    switch_modal.style.display = "block"
});

x_btn.addEventListener('click', function() {
switch_modal.style.display = "none"
});
      
send_message_btn.addEventListener('click', function(){
new_message_modal.classList.remove('hidden');
});

x.addEventListener('click', function(){
  new_message_modal.classList.add('hidden');
  });