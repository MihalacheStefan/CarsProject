import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarListComponent } from './Cars/car-list/car-list.component';
import { CarDetailComponent } from './Cars/car-detail/car-detail.component';
import { ChassisDetailComponent } from './Cars/chassis-detail/chassis-detail.component';
import { EngineDetailComponent } from './Cars/engine-detail/engine-detail.component';
import { UserListDetailComponent } from './Cars/user-list-detail/user-list-detail.component';
import { AdDirective } from './ad.directive';
import { AdBannerComponent } from './Ads/ad-banner/ad-banner.component';
import { ChassisAdComponent } from './Ads/chassis-ad/chassis-ad.component';

@NgModule({
  declarations: [
    AppComponent,
    CarListComponent,
    CarDetailComponent,
    ChassisDetailComponent,
    EngineDetailComponent,
    UserListDetailComponent,
    AdDirective,
    AdBannerComponent,
    ChassisAdComponent
  ],
  entryComponents: [ ChassisAdComponent, ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
