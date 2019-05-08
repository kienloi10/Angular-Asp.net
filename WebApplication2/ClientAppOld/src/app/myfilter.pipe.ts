import { Pipe, PipeTransform } from '@angular/core';
import { Product } from './Object/Product';

@Pipe({
  name: 'myfilter'
})
export class MyfilterPipe implements PipeTransform {

  transform(items: Product[], searchText: string): Product[] {
    if (!items || !searchText) return items;

    return items.filter(it =>
      it.nameProduct.toLowerCase().indexOf(searchText.toLowerCase()) !== -1);
  }

}
