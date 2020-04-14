import { Component, OnInit, ViewChild, ComponentFactoryResolver, OnDestroy } from '@angular/core';
import { AdItem } from '../ad-item';
import { AdDirective } from 'src/app/ad.directive';
import { ChassisService } from 'src/app/services/chassis.service';
import { ChassisAdComponent } from '../chassis-ad/chassis-ad.component';
import { AdComponentInterface } from '../ad-component.interface';


@Component({
  selector: 'app-ad-banner',
  templateUrl: './ad-banner.component.html',
  styleUrls: ['./ad-banner.component.css']
})
export class AdBannerComponent implements OnInit, OnDestroy {
  ads: AdItem[] = [];
  currentAdIndex = -1;
  @ViewChild(AdDirective, {static: true}) adHost: AdDirective;
  interval: any;

  constructor(private chassisService: ChassisService,
              private componentFactoryResolver: ComponentFactoryResolver) { }

  ngOnInit() {
    this.getChassiss().then(() => {
        setTimeout(() => {
            this.loadComponent();
            this.getAds();
        }, 500);
    });
  }

  ngOnDestroy() {
    clearInterval(this.interval);
  }

  async getChassiss() {
    await this.chassisService.getChassiss().subscribe(data => {
      data.forEach(chassisData => {
        this.ads.push(new AdItem(ChassisAdComponent, chassisData));
      });
    });
  }

  loadComponent() {
     this.currentAdIndex = (this.currentAdIndex + 1) % this.ads.length;
     
     const adItem = this.ads[this.currentAdIndex];

     const componentFactory = this.componentFactoryResolver.resolveComponentFactory(adItem.component);

     const viewContainerRef = this.adHost.viewContainerRef;
     viewContainerRef.clear();

     const componentRef = viewContainerRef.createComponent(componentFactory);
     (componentRef.instance as AdComponentInterface).data = adItem.data;
  }

  getAds() {
    this.interval = setInterval(() => {
      this.loadComponent();
    }, 3000);
  }
}
