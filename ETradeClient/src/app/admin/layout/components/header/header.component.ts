import { Component, Input, ViewChild, ViewChildren } from '@angular/core';
import { MatDrawer } from '@angular/material/sidenav';
import { SlidebarComponent } from '../slidebar/slidebar.component';
import { LayoutComponent } from '../../layout.component';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {
 @Input() drawer : MatDrawer
 closeDrawer(){
  this.drawer.toggle()
 }
}
