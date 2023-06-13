import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountClient, RegisterCommad } from 'src/BestBuyPortal-Api/bestBuy-api';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registrationForm!: FormGroup|any;
   constructor( private empClient: AccountClient,private route:Router, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.registrationForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(10),
          Validators.pattern(
            /^(?=.*[!@#$%^&*()_+\-=[\]{};':"\\|,.<>/?])(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).*$/
          ),
        ],
      ],
      address: ['', Validators.required],
    });
}
Register():void{
  debugger;
  this.empClient.registerRequest(<RegisterCommad>{
  name:this.registrationForm.name,
email:this.registrationForm.email,
address:this.registrationForm.address,
password:this.registrationForm.password
  }).subscribe((response)=>{
    console.log(response);
  })
  
}
onEmailInput(event: any) {
  const email = event.target.value;
  const dotComIndex = email.indexOf('.com');
  if (dotComIndex !== -1 && email.length > dotComIndex + 4) {
    event.target.value = email.slice(0, dotComIndex + 4);
    this.registrationForm.controls.email.setValue(event.target.value);
  }
}
}
