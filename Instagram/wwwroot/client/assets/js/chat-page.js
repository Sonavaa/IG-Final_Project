"use strict";
const smile = document.querySelector(".fa-face-smile")
const new_message_modal = document.querySelector(".new-message-modal")
const new_message_director = document.querySelector(".new-message-director")
const x = document.querySelector(".fa-times")
      
$(function() {
  // Initializes and creates emoji set from sprite sheet
  window.emojiPicker = new EmojiPicker({
    emojiable_selector: '[data-emojiable=true]',
    assetsPath: './client/assets/lib/img/',
    popupButtonClasses: 'fa fa-smile-o'
  });
  // Finds all elements with `emojiable_selector` and converts them to rich emoji input fields
  // You may want to delay this step if you have dynamically created input fields that appear later in the loading process
  // It can be called as many times as necessary; previously converted input fields will not be converted again
  window.emojiPicker.discover();
});

new_message_director.addEventListener('click', function(){
new_message_modal.classList.remove('hidden');
});

x.addEventListener('click', function(){
  new_message_modal.classList.add('hidden');
  });