import { RegisterComponent } from './Component/register/register.component';
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { BestBuyRoutingModule } from "./bestBuy-routing.module";
import { NgModule } from "@angular/core";
import { MaterialModule } from "src/material/material.module";
import { DemoComponent } from "./Component/demo.component";
import { LoginComponent } from './Component/login/login.component';

@NgModule({
    declarations: [

    DemoComponent,
    RegisterComponent,
    LoginComponent
      
    ],
    imports: [CommonModule, FormsModule, ReactiveFormsModule, BestBuyRoutingModule, MaterialModule],
  })
  export class BestBuyModule {}