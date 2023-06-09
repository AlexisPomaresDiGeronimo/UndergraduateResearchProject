import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './sharepages/navbar/navbar.component';
import { FooterComponent } from './sharepages/footer/footer.component';
import { HomeComponent } from './pages/home/home.component';
import { accommodationComponent } from './pages/accommodation/accommodation.component';
import { EntertainmentComponent } from './pages/entertainment/entertainment.component';
import { SightseeingComponent } from './pages/sightseeing/sightseeing.component';
import { TransportationComponent } from './pages/transportation/transportation.component';
import { ContactComponent } from './pages/contact/contact.component';

import { ApiUrlService } from './services/apiservice.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    HomeComponent,
    accommodationComponent,
    EntertainmentComponent,
    SightseeingComponent,
    TransportationComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    ApiUrlService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
