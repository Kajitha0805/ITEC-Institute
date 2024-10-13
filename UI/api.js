export async function getAdmin() {
    const response = await fetch('http://localhost:3000/admin');
    const data = await response.json();
    return data;
  }


  export async function editAdmin(newPassword){
    await fetch('http://localhost:3000/admin/1', {
    method: 'PATCH',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({ password: newPassword })
  })      
}

export async function addStudents(obj){
  await fetch('http://localhost:3000/followup',{
    method:'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({"name":obj.Name, "mobile":obj.Mobile, "course":obj.Course, "date":obj.Date, "email":obj.Email, "address":obj.Address, "description":obj.Description})
  })
  
}


// export async function getStudentById(id) {
//   const response = await fetch(`http://localhost:3000/students/${id}`);
//   const data = await response.json();
//   return data;
// }

export async function updateStudent(putId, putStudents) {
  const response = await fetch(`http://localhost:5064/api/Student/Update_Student?NicNo=${putId}`, {
    method: 'PATCH',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({firstName:putStudents.Fname, lastName:putStudents.Lname, courseId:putStudents.Course, batch:putStudents.Batch, mobileNo:putStudents.Mobile, email:putStudents.Email, address:putStudents.Address})
  });
}

export async function getStudents() {
  const response = await fetch('http://localhost:5064/api/Student/Get_All_Student');
  const data = await response.json();
  console.log(data);
  return data;
}


export async function removeSingleStudent(nicNo) {
  await fetch(`http://localhost:5064/api/Student/Delete_Student-By-Id?NicNo=${nicNo}`, {
  method:'DELETE'
  });
}

export async function addNewCourse(courseDetails){
  await fetch('http://localhost:5064/api/Course/Create_Course',{
    method:'POST',
    body: courseDetails
  })
}

export async function getCourses() {
  const response = await fetch('http://localhost:5064/api/Course/Get_All_Course');
  const data = await response.json();
  console.log(data)
  return data;
}

export async function addNewStudent(obj){
  await fetch('http://localhost:5064/api/Student/Create_Student',{
    method:'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({"id":obj.nicNo, "firstname":obj.firstName, "lastname":obj.lastName, "course":obj.courseId, "batch":obj.batch, "date":obj.date, "mobile":obj.mobileNo, "email":obj.email, "address":obj.address, "regfee":obj.regFee, "addifee":obj.additionalFee})
  })
}


export async function getSingleCourse(id) {
  const response = await fetch(`http://localhost:5064/api/Course/Get_Course_By_Id?CourseId=${courseId}`);
  const data = await response.json();
  return data;
}


export async function courseUpdate(courseId, obj) {
  const updateData={courseName:obj.eCourseName, duration:obj.eDuration, fee:obj.eFee, instructor:obj.eInstructor, syllabus:obj.eSyllabus};
  console.log(updateData)
  const response = await fetch(`http://localhost:5064/api/Course/Update_Course?CourseId=${courseId}`, {
    method: 'PATCH',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify(updateData)
  });
}


export async function deleteSingleCourse(courseId) {
  await fetch(`http://localhost:5064/api/Course/Delete_Course_By_Id?CourseId=${courseId}`, {
  method:'DELETE'
  });
}


export async function addPayment(obj){
  await fetch('http://localhost:3000/payments',{
    method:'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({"id":obj.studentId, "date":obj.studentDate, "fee":obj.studentAddiFee})
  })
  
}

export async function getPayment() {
  const response = await fetch('http://localhost:3000/payments');
  const data = await response.json();
  return data;
}


export async function addModule(obj){
  await fetch('http://localhost:3000/modules',{
    method:'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({"title":obj.mModuleTitle, "course":obj.mCourseList, "batch":obj.mModulebatch, "date":obj.mModuleDate, "file":obj.mModuleFile, "description":obj.mModuleDescription})
  })
  
}

export async function getAllModules() {
  const response = await fetch('http://localhost:3000/modules');
  const data = await response.json();
  return data;
}


export async function addExpense(obj){
  await fetch('http://localhost:3000/expense',{
    method:'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({"title":obj.title, "date":obj.date, "price":obj.price, "receipt":obj.receipt, "file":obj.mModuleFile, "description":obj.description})
  })
  
}


export async function changeRegFee(newReg){
  await fetch('http://localhost:3000/registrationfee/1', {
  method: 'PATCH',
  headers: {'Content-Type': 'application/json'},
  body: JSON.stringify({ regfee: newReg })
})      
}

export async function getRegFee() {
  const response = await fetch('http://localhost:3000/registrationfee');
  const data = await response.json();
  return data;
}


export async function addBatch(obj){
  await fetch('http://localhost:3000/batch',{
    method:'POST',
    headers: {'Content-Type': 'application/json'},
    body: JSON.stringify({"batchname":obj.batch})
  })
  
}

export async function getBatch() {
  const response = await fetch('http://localhost:3000/batch');
  const data = await response.json();
  return data;
}


export async function getFollowup() {
  const response = await fetch('http://localhost:3000/followup');
  const data = await response.json();
  return data;
}

export async function getExpense() {
  const response = await fetch('http://localhost:3000/expense');
  const data = await response.json();
  return data;
}


