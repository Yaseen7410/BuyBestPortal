import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { DemoComponent } from "./Component/demo.component";
import { RegisterComponent } from "./Component/register/register.component";
import { LoginComponent } from "./Component/login/login.component";


const routes : Routes=[

    {path : "demoList" ,component: DemoComponent},
    {path:"register",component:RegisterComponent},
    {path:"login",component:LoginComponent}


]

@NgModule({
    imports:[RouterModule.forChild(routes)],
    exports:[RouterModule]
})
export class BestBuyRoutingModule{}
