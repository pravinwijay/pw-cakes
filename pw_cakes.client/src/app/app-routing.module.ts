import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PasserCommandeComponent } from './partie_client/passer-commande/passer-commande.component';
import { AccueilClientComponent } from './partie_client/accueil-client/accueil-client.component';

const routes: Routes = [
  {path: 'passer-commande', component: PasserCommandeComponent},
  {path: '', component: AccueilClientComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
