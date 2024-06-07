const smile = document.querySelector(".fa-face-smile")
const more_span= document.querySelector("#more-span")
const less_span = document.querySelector("#less-span")
const userName_in_comment = document.querySelector("#userName")
let comment_text = document.querySelector("#comment")
const delete_Modal = document.querySelector(".delete-cancel")
const cancel_btn = document.querySelector(".delete-cancel p")
const comment_view = document.querySelector(".comment-view")
const ellipsis_btn = document.querySelector(".cmt .fa-ellipsis")
const follow_following = document.querySelector("#follow-or-following")
const heart_icon_for_like = document.querySelector(".fa-heart")
const post = document.querySelector(".detail-post-view-side")

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

let subString = comment_text.innerText.substring(0, 50);
const original_commit_text = comment_text.innerText;
comment_text.innerText = subString

more_span.addEventListener("click", function(e) {
  comment_text.innerText = original_commit_text;
  if(comment_text.innerText = original_commit_text){
    more_span.style.display = "none";
    less_span.style.display = "block";
  }
  else{
    less_span.style.display = "none";
    more_span.style.display = "block";
  }
});

less_span.addEventListener("click", function(e) {
  comment_text.innerText = subString;
  if(comment_text.innerText = subString){
    more_span.style.display = "block";
    less_span.style.display = "none";
  }
  else{
    less_span.style.display = "none";
    comment_text.innerText = subString
    more_span.style.display = "block";
  } 
});

ellipsis_btn.addEventListener("click", function (e) {
  delete_Modal.style.display = "flex";
});

cancel_btn.addEventListener("click", function (e) {
  delete_Modal.style.display = "none";
});

// window.addEventListener("click", function (e) {
//   while(delete_Modal.style.display == "flex"){
//   delete_Modal.style.display = "none";
//   }
// });

follow_following.addEventListener("click", function (e) {
  if(follow_following.innerText == "Follow"){
    follow_following.innerText = "Following"
  }
  else{
    follow_following.innerText = "Follow"
  }
});

heart_icon_for_like.addEventListener("click", function (e) {
  if(heart_icon_for_like.classList.contains("fa-regular")){
    heart_icon_for_like.classList.remove("fa-regular")
    heart_icon_for_like.classList.add("fa-solid")
    heart_icon_for_like.style.color = "red"
  }
  else{
    heart_icon_for_like.classList.remove("fa-solid")
    heart_icon_for_like.classList.add("fa-regular")
    heart_icon_for_like.style.color = "white"
  }
});
post_view_on_modal_modal.addEventListener("dblclick", function(){
  if(heart_icon_for_like.classList.contains("fa-regular")){
    heart_icon_for_like.classList.remove("fa-regular")
    heart_icon_for_like.classList.add("fa-solid")
    heart_icon_for_like.style.color = "red"
    console.log("ads")
  }
  else{
    heart_icon_for_like.classList.remove("fa-solid")
    heart_icon_for_like.classList.add("fa-regular")
    heart_icon_for_like.style.color = "white"
    console.log("nads")
  }
});