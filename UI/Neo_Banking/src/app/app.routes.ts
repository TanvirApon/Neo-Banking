import { Routes } from '@angular/router';
import { Register } from './pages/auth/register/register';
import { Dashboard } from './pages/user/dashboard/dashboard';
import { TransactionForm } from './pages/user/transactions/transaction-form/transaction-form';
import { TransactionHistory } from './pages/user/transactions/transaction-history/transaction-history';
import { TransactionMonitoring } from './pages/admin/transaction-monitoring/transaction-monitoring';
import { AccountManagement } from './pages/admin/account-management/account-management';
import { AdminDashboard } from './pages/admin/admin-dashboard/admin-dashboard';
import { FraudLogs } from './pages/admin/fraud-logs/fraud-logs';
import { UserManagement } from './pages/admin/user-management/user-management';


export const routes: Routes = [

  { path: '', redirectTo: 'login', pathMatch: 'full' },

  { path: 'register', component:Register },

  { path:"user-dashboard", component:Dashboard},

  { path:"user-transaction", component:TransactionForm },

  { path:"user-transaction-history", component:TransactionHistory},

  { path:"admin-transaction",component:TransactionMonitoring },

  { path: "admin-account-management",component:AccountManagement },

  { path:"admin-dashboard", component:AdminDashboard },

  { path:"admin-fraud-logs", component:FraudLogs },

  { path:"admin-user-management", component:UserManagement }


];
