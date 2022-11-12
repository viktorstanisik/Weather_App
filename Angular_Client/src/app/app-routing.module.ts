import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GetWeatherComponent } from './get-weather/get-weather.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'getweather', component:GetWeatherComponent, canActivate: [AuthGuard]},
  {path: '**', component: LoginComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
