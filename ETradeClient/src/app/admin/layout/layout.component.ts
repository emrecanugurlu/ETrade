import { AfterContentInit, AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { SlidebarComponent } from './components/slidebar/slidebar.component';
import { MatDrawer } from '@angular/material/sidenav';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements AfterViewInit{
  ngAfterViewInit(): void {
    this.hc.drawer = this.sbc.drawer
  }
  
  @ViewChild(SlidebarComponent) sbc : SlidebarComponent
  @ViewChild(HeaderComponent) hc : HeaderComponent
  
}
