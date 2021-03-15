import SessionPage from 'pages/session/session.page';
import SessionsPage from 'pages/sessions/sessions.page';

export type RouteType = {
  component: any,
  path: string,
};

export const defaultRoute: RouteType = {
  component: SessionsPage,
  path: '/',
};

const routes: RouteType[] = [
  defaultRoute,
  {
    component: SessionPage,
    path: '/session/:sessionId',
  },
];

export default routes;