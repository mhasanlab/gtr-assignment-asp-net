import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductComponent } from './product/product.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {path:"register", component:RegisterComponent},
  {path:"login", component:LoginComponent},
  {path:"product", component:ProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
