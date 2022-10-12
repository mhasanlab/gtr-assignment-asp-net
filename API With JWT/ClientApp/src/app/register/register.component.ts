import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder } from '@angular/forms';
import { Route } from '@angular/router';
import { Role } from '../Models/role';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public registerForm = this.formBuilder.group({
    fullName:['',[Validators.required]],
    email: ['', [Validators.email, Validators.required]],
    password: ['', Validators.required]
  })
  // public roles:Role[]=[];
  // public registerForm;
  constructor(private formBuilder:FormBuilder,private userServie:UserService) { }

  ngOnInit(): void {
    
  }
  onSubmit(){
    console.log("On Submit")
    let fullName=this.registerForm.controls["fullName"].value;
    let email=this.registerForm.controls["email"].value;
    let password=this.registerForm.controls["password"].value;

    this.userServie.register(fullName, email, password).subscribe((data)=>{
      console.log("response", data)
    },error=>{
      console.log("error",error)
    
    })

  }

}
