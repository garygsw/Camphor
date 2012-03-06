using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Camphor.Model;
using Camphor.View;

namespace Camphor.Controller {
    class StudentParticularsManager {
        protected Server server;

        public StudentParticularsManager (Server server) {
            this.server = server;
        }

        protected StudentParticularsManager () { }

        public void ChangeStudentParticulars (string matric, string name, string password, string school, Gender gender) {
            // FUNCTION: change the particulars of the students including password
            // PRE-CONDITIONS: assuming matric exist
            // POST-CONDITIONS: 
            Student student = server.GetStudent(matric);
            student.name = name;
            student.password = password;
            student.school = school;
            student.gender = gender;
        }

        public void ChangeStudentParticulars (string matric, string name, string password) {
            // FUNCTION: change the particulars of the students
            // PRE-CONDITIONS: assuming matric exist
            // POST-CONDITIONS: 
            Student student = server.GetStudent(matric);
            student.name = name;
            student.password = password;
        }

        public void AddStudentParticulars (string matric, Gender gender, string name, string password, string school) {
            // FUNCTION: add the particulars of the students
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            Student student = new Student();
            student.matric = matric;
            student.name = name;
            student.password = password;
            student.school = school;
            student.gender = gender;
            server.AddStudent(student);
        }

        public void DeleteStudentParticulars (string matric) {
            // FUNCTION: delete the particulars of the students
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            server.DeleteStudent(matric);
        }

        public string GetPassword (string matric) {
            // FUNCTION: get the password of a student
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.GetStudent(matric).password;
        }

        public string GetName (string matric) {
            // FUNCTION: get the name of a student
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.GetStudent(matric).name;
        }

        public string GetSchool (string matric) {
            // FUNCTION: get the school of a student
            // PRE-CONDITIONS: 
            // POST-CONDITIONS: 
            return server.GetStudent(matric).school;
        }

        public Gender GetGender(string matric) {
            return server.GetStudent(matric).gender;
        }

    }
}
