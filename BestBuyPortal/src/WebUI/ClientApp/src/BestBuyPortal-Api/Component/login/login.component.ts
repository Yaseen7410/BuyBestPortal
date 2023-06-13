import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { first, map } from 'rxjs/operators';
import { AuthServiceService } from 'src/BestBuyPortal-Api/Services/auth-service.service';
 
@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  errorMessage = '';
  showPasswordField=false;
  hideContinue=false;
  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthServiceService
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) { 
      this.router.navigate(['/']);
  }
  
  }
  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      name: ['', Validators.required],
      password: ['', Validators.required]
  });

  // get return url from route parameters or default to '/'
  this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
}
get f() { return this.loginForm.controls; }

submit():void{
debugger;
  this.submitted = true;

  // stop here if form is invalid
  if (this.loginForm.invalid) {
      return;
  }  

  this.loading = true;
 
  this.authenticationService.login(this.f.name.value, this.f.password.value)
  .pipe(first())
  .subscribe(
    (data: any) => {
      
      if (data.succeeded) {
        this.loading = false;
        location.reload();
        //this.success();
        // this.successMessage = data.lists;
        //console.log(this.successMessage);
        this.router.navigateByUrl('/home');
       
      } else {
        console.log(data.errors);

        this.errorMessage = data.errors;
       
        this.loading = false;
        this.router.navigateByUrl('/home/login');
      }

      //  this.errorMessage = localStorage.getItem('currentUser');

      //  splitString(this.errorMessage);
      // alert(this.errorMessage);
    },
    (error: any) => {
      this.router.navigateByUrl('/login');
      this.loading = false;
    }
  );
}

}
