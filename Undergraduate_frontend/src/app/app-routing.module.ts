import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccommondationComponent } from './pages/accommondation/accommondation.component';
import { ContactComponent } from './pages/contact/contact.component';
import { EntertainmentComponent } from './pages/entertainment/entertainment.component';
import { HomeComponent } from './pages/home/home.component';
import { SightseeingComponent } from './pages/sightseeing/sightseeing.component';
import { TransportationComponent } from './pages/transportation/transportation.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:'accommondation', component:AccommondationComponent},
  {path:'entertainment', component:EntertainmentComponent},
  {path:'sightseeing',component:SightseeingComponent},
  {path:'transportation',component:TransportationComponent},
  {path:'contact',component:ContactComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
