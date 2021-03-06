﻿// Source: https://github.com/dwyl/html-form-send-email-via-google-script-without-server

// get all data in form and return object
function getFormData() {
    var data = {};
    data.email = document.getElementById("email").value;
    data.message = document.getElementById("message").value;
    data.name = document.getElementById("name").value;
    data.telephone = document.getElementById("telephone").value;
    //console.log(data);
    return data;
}

function handleFormSubmit(event) {  // handles form submit withtout any jquery
    event.preventDefault();           // we are submitting via xhr below
    grecaptcha.execute();
    var data = getFormData();         // get the values submitted in the form
    var url = event.target.action;  
    var xhr = new XMLHttpRequest();
    xhr.open('POST', url);
    // xhr.withCredentials = true;
    xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
    xhr.onreadystatechange = function () {
        //console.log(xhr.status, xhr.statusText)
        //aconsole.log(xhr.responseText);
        document.getElementById('gform').style.display = 'none'; // hide form
        document.getElementById('thankyouMessage').style.display = 'block';
        return;
    };
    // url encode form data for sending as post data
    var encoded = Object.keys(data).map(function (k) {
        return encodeURIComponent(k) + '=' + encodeURIComponent(data[k])
    }).join('&')
    xhr.send(encoded);
}

function loaded() {
    console.log('contact form submission handler loaded successfully');
    // bind to the submit event of our form
    var form = document.getElementById('gform');
    form.addEventListener("submit", handleFormSubmit, false);
};

document.addEventListener('DOMContentLoaded', loaded, false);

//For the Google reCAPTCHA
function onSubmit(token) {
    document.getElementById("demo-form").submit();
}