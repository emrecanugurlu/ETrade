import { Component } from '@angular/core';
declare var $: any

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ETradeClient';

  constructor() {
    $.get("https://localhost:7120/api/product", function (data: string) {
      console.log(data);
    })
  }
}
