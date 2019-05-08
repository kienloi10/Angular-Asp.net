import { Component, OnInit } from '@angular/core';
import { Console } from '@angular/core/src/console';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Object/Product';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})

export class ProductComponent implements OnInit {
  //getProduct = PRODUCT;
  public getProduct: Product[];
  closeResult: string;

  constructor(http: HttpClient, public modalService: NgbModal) {
    http.get<Product[]>('https://localhost:44369/api/Test').subscribe(result => {
      this.getProduct = result;
      console.log(result);
    }, error => console.error(error));
  }
  open(content) {
    this.modalService.open(content).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  ngOnInit() {
  }

}


export const PRODUCT: Product[] = [
  {
    id: 1,
    nameProduct: 'Apple',
    qty: 2,
    amount: 2000
  },
  {
    id: 2,
    nameProduct: 'Orange',
    qty: 3,
    amount: 3000
  },
  {
    id: 3,
    nameProduct: 'Peace',
    qty: 6,
    amount: 6000
  }
]





