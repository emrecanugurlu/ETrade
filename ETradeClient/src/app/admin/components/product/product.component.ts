import { Component, OnInit } from '@angular/core';
import { HttpClientService } from 'src/app/services/common/http-client.service';
import { ProductServiceService } from '../../../services/model/product-service.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  constructor(productService: ProductServiceService) {
    
    
  }

  ngOnInit(): void {
    
  }

  

}
