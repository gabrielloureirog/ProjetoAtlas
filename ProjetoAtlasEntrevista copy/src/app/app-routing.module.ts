import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FuncionariosComponent } from './funcionarios/funcionarios.component';

const routes: Routes = [
  { path: '', redirectTo: '/funcionarios', pathMatch: 'full' },
  { path: 'funcionarios', component: FuncionariosComponent   },
];


@NgModule({
  imports:
  [
    RouterModule.forRoot(routes, {onSameUrlNavigation : 'reload'}),
  ],

  exports: [RouterModule]
})
export class AppRoutingModule { }
