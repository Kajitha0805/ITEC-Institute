let modalContainer = document.getElementById("modalContainer");
let signInPart = document.getElementById("signInPart");
let signUpPart = document.getElementById("signUpPart");


document.getElementById("navBarLogin").onclick = function (event) {
    event.preventDefault();
    signUpPart.style.display = "none";
    signInPart.style.display = "block";
    modalContainer.style.display = "flex";
}

document.getElementById("loginClose").onclick = function () {
    modalContainer.style.display = "none";
}



document.getElementById("register").onclick = function (event) {
    event.preventDefault();
    signInPart.style.display = "none";
    signUpPart.style.display = "block";

}

document.getElementById("backToLogin").onclick = function (event) {
    event.preventDefault();
    signUpPart.style.display = "none";
    signInPart.style.display = "block";
}






/////adding new student in db.json//

const nic = document.getElementById("nic_input")
const first = document.getElementById("first_name")
const email_id = document.getElementById("emial_id")
const last = document.getElementById("last_name")
const mo_no = document.getElementById("Mobile_no")
const address = document.getElementById("Address_id")
const password = document.getElementById("Password_id")

///// selecting buttton///




const creating_button = document.getElementById("creating_button")


//////
let selceted_student = false
creating_button.addEventListener('click', () => {

    //// getting students details to veryfiy wether there is same register///
    fetch('http://localhost:3000/student_register')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {

            for (let i = 0; i < data.length; i++) {
                if (data[i].id == nic.value) {
                    alert("User already has an account");
                    break;
                }
                else {
                    selceted_student = true
                }
            }
            console.log(data);
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });


    ///////

    if (selceted_student) {
        let new_obj = {
            "id": nic.value,
            "firstname": first.value,
            "lastname": last.value,
            "date": new Date().toISOString().split('T')[0],
            "mobile": mo_no.value,
            "email": email_id.value,
            "address": address.value,
            "Password":password.value
        }
        alert("Registered Sucessfully")
        console.log(new_obj)
        postData('http://localhost:3000/student_register', new_obj);
    }

})

///// function to post using feth api//
const postData = (url, data) => {
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log('Success:', data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
};

//// getting fetch api methods///
// Define the URL you want to fetch data from


// Use the Fetch API to make a GET request


const sign_Nic = document.getElementById("Nicno_signIn")
const sign_password = document.getElementById("password_sign")

let selected_signin_user = false

////sign in btn//

const sign_btn = document.getElementById("loginbtn")

sign_btn.addEventListener('click', () => {
    fetch('http://localhost:3000/student_register')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {

            for (let i = 0; i < data.length; i++) {
                if (data[i].id == sign_Nic.value&&data[i].Password==sign_password.value) {
                    alert("You are Loging");
                    selected_signin_user=false
                    window.location.href = '../studentDashboard/studentDashboard.html';
                    
                    break;
                    
                }
                else {
                    selected_signin_user=true
                }
            }
        
        })
        .catch(error => {
            console.error('There was a problem with the fetch operation:', error);
        });

        if(selected_signin_user){
            alert("Please enter correct NIC number & password")
        }

})






