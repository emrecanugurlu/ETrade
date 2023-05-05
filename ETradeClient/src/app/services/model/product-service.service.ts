import { Injectable } from '@angular/core';
import { ProductCreate } from '../../contracts/product-create';
import { HttpClientService } from '../common/http-client.service';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  constructor(private httpClientService: HttpClientService) { }

  CreateProduct(product: ProductCreate) {
    console.log("deneme")
    this.httpClientService.post({ controller: "product" }, product).subscribe(result => { console.log("İşlem Başarılı") })
  }
}
