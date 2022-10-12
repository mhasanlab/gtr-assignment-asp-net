import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  products:any;
  products$:any;
  constructor(private productData:ProductsService){
    
  }

  ngOnInit(): void {
    // this.productData.Getproducts().subscribe((data)=>{
    //   this.products=data;
  this.products$=  this.productData.Getproducts();
    
  }

}
