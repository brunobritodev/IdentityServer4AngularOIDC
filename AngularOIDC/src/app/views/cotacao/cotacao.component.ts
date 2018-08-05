import { Component, OnInit } from '@angular/core';
import { Observable, Subscription } from '../../../../node_modules/rxjs';
import { CotacaoService } from './cotacao.service';
import { IntervalObservable } from "rxjs/observable/IntervalObservable";
import { Moedas } from '../../shared/models/moedas.model';

@Component({
  templateUrl: './cotacao.component.html',
  styleUrls: ['./cotacao.component.scss']
})
export class CotacaoComponent implements OnInit {

  public cotacoes: Observable<Moedas[]>;
  sub: Subscription;
  constructor(private cotacaoService: CotacaoService) { }

  ngOnInit() {
    this.obterCotacoes();
    this.sub = IntervalObservable.create(35000).subscribe(() => this.obterCotacoes());
  }

  public ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  public obterCotacoes() {
    this.cotacoes = this.cotacaoService.obterCotacoes();
  }
}
