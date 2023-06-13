import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './layout/home/home.component';
import { NgModule } from '@angular/core';


const routes: Routes = [
    {path:'',redirectTo:"/home/demoList", pathMatch:"full"},
   { path: 'home', component: HomeComponent, loadChildren: () =>

   import('../BestBuyPortal-Api/bestBuy.module').then((m) => m.BestBuyModule) },
   /* Not found redirection */
   { path: "**", redirectTo: '/home/demoList' },  


   
   //{path:"/home/login",component:LoginComponent}
 ];
 
 @NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule]
 })
 export class AppRoutingModule { }