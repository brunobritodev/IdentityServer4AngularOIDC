import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CotacaoComponent } from './cotacao.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: CotacaoComponent
  }
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule],
  declarations: [CotacaoComponent]
})
export class CotacaoModule { }
