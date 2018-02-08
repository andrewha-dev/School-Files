package b31_l07_basic_collection;
import inheritance.*;

import java.util.Collection;
import java.util.Iterator;

public class B31_L07_Generics
{
  public B31_L07_Generics()
  {
  } // B31_L07_Generics()
  public void whatAreYou(Collection<Object> coll)
  {
  	for(Object i : coll)
  		System.out.println(i.getClass());
  }
  public void showMe(Collection<?> coll)
  {
  	for(Object i : coll)
  		System.out.println(i.getClass());
  }
  public void talkNow(Collection<Animal> coll)
  {
  	for(Object i : coll)
  		((Animal) i).speak();
  }
  public void everybodySpeak(Collection<? extends Animal> coll)
  {
  	for(Object i : coll)
  		((Animal) i).speak();
  }
  public <E> void whoAreYou(Collection<E> coll)
  {
  	for(Object i : coll)
  		System.out.println(i.getClass());
  }
  
} // B31_L07_Generics
