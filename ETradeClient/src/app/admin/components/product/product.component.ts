import { Component, OnInit } from '@angular/core';
import { HttpClientService } from 'src/app/services/common/http-client.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  httpClientService : HttpClientService
  constructor(httpClientService : HttpClientService){
    this.httpClientService = httpClientService
    
  }

  ngOnInit(): void {
    this.httpClientService.get({fullEndPoint :"https://jsonplaceholder.typicode.com/posts"}).subscribe(data=>console.log(data))
    // this.httpClientService.post({controller :"product"},{name:"Kalem",description:"deneme",stock:12,price:23.3}).subscribe()
    // this.httpClientService.put({controller:"product"},{id:"349374CA-FDEB-4428-9DD8-08DB4AFB8301",name:"Kalem 1",description:"deneme 1",stock:121,price:23.31}).subscribe()
    //this.httpClientService.delete({controller:"product"},"538AA25E-2610-42DE-5D26-08DB4A5F92A9").subscribe()
  }

  

}
