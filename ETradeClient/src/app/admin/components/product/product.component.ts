import {Component, OnInit, ViewChild} from '@angular/core';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import {ProductService} from "../../../services/model/product.service";
import {ListComponent} from "./list/list.component";
import {ProductCreate} from "../../../contracts/product_create";


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  constructor(productService: ProductService) {
  }

  @ViewChild(ListComponent) listComponent : ListComponent
  createProductEvent(product : ProductCreate){
    console.log("Tetiklendi")
      this.listComponent.getProducts()
  }

  ngOnInit(): void {

  }



}
