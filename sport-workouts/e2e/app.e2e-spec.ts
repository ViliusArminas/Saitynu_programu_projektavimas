import { SportWorkoutsPage } from './app.po';

describe('sport-workouts App', () => {
  let page: SportWorkoutsPage;

  beforeEach(() => {
    page = new SportWorkoutsPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
