import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarListComponent } from './car-list/car-list.component';
import { CarDetailComponent } from './car-detail/car-detail.component';
import { ChassisDetailComponent } from './chassis-detail/chassis-detail.component';
import { EngineDetailComponent } from './engine-detail/engine-detail.component';
import { UserListDetailComponent } from './user-list-detail/user-list-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    CarListComponent,
    CarDetailComponent,
    ChassisDetailComponent,
    EngineDetailComponent,
    UserListDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
