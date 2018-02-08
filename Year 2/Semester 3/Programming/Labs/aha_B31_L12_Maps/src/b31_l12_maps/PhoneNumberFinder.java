package b31_l12_maps;

import java.awt.BorderLayout;
import java.awt.Dimension;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import java.io.Serializable;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class PhoneNumberFinder
  extends JFrame implements Serializable
{
  private PhoneDirectory directory = new MapPhoneDirectory();
  private BorderLayout layoutMain = new BorderLayout();
  private JPanel panelCenter = new JPanel();
  private JMenuBar menuBar = new JMenuBar();
  private JMenu menuFile = new JMenu();
  private JMenu menuSearch = new JMenu();
  private JMenuItem menuFileNew = new JMenuItem();
  private JMenuItem menuFileExit = new JMenuItem();
  private JMenuItem menuSearchFind = new JMenuItem();
  private JLabel statusBar = new JLabel();
  private JTextField firstNameFld = new JTextField();
  private JLabel firstNameLbl = new JLabel();
  private JTextField lastNameFld = new JTextField();
  private JLabel lastNameLbl = new JLabel();
  private JTextField phoneFld = new JTextField();
  private JLabel phoneLbl = new JLabel();
  private JButton changeBtn = new JButton();
  private JButton deleteBtn = new JButton();
  private JButton addBtn = new JButton();

  public PhoneNumberFinder()
  {
    try
    {
      jbInit();
    }
    catch (Exception e)
    {
      e.printStackTrace();
    }
  }

  private void jbInit()
    throws Exception
  {
    this.setJMenuBar(menuBar);
    this.getContentPane().setLayout(layoutMain);
    panelCenter.setLayout(null);
    this.setSize(new Dimension(400, 300));
    this.setTitle("My Friends Phone Numbers");
    menuFile.setText("File");
    menuFileNew.setText("New");
    menuFileNew.addActionListener(new ActionListener()
      {
        public void actionPerformed(ActionEvent ae)
        {
          fileNew_ActionPerformed(ae);
        }
      });

    menuFile.add(menuFileNew);
    menuFileExit.setText("Exit");
    menuFileExit.addActionListener(new ActionListener()
      {
        public void actionPerformed(ActionEvent ae)
        {
          fileExit_ActionPerformed(ae);
        }
      });
    statusBar.setText("");
    menuFile.add(menuFileExit);
    menuBar.add(menuFile);
    menuSearch.setText("Search");
    menuSearchFind.setText("Find phone number");
    menuSearchFind.addActionListener(new ActionListener()
      {
        public void actionPerformed(ActionEvent ae)
        {
          searchFind_ActionPerformed(ae);
        }
      });

    menuSearch.add(menuSearchFind);
    menuBar.add(menuSearch);
    statusBar.setText("");
    firstNameLbl.setText("First Name:");
    lastNameLbl.setText("Last Name:");
    phoneLbl.setText("Phone Number:");
    firstNameLbl.setBounds(new Rectangle(80, 55, 90, 25));
    firstNameFld.setBounds(new Rectangle(165, 55, 90, 25));
    lastNameLbl.setBounds(new Rectangle(80, 95, 90, 25));
    lastNameFld.setBounds(new Rectangle(165, 95, 90, 25));
    phoneLbl.setBounds(new Rectangle(80, 135, 90, 25));
    phoneFld.setBounds(new Rectangle(165, 135, 90, 25));
    addBtn.setText("Add");
    addBtn.setBounds(new Rectangle(25, 185, 75, 30));
    addBtn.addActionListener(new ActionListener()
      {
        public void actionPerformed(ActionEvent e)
        {
          addBtn_actionPerformed(e);
        }
      });
    changeBtn.setText("Change");
    changeBtn.setBounds(new Rectangle(128, 185, 75, 30));
    changeBtn.addActionListener(new ActionListener()
      {
        public void actionPerformed(ActionEvent e)
        {
          changeBtn_actionPerformed(e);
        }
      });
    deleteBtn.setText("Delete");
    deleteBtn.setBounds(new Rectangle(230, 185, 75, 30));

    deleteBtn.addActionListener(new ActionListener()
      {
        public void actionPerformed(ActionEvent e)
        {
          deleteBtn_actionPerformed(e);
        }
      });

    this.getContentPane().add(statusBar, BorderLayout.SOUTH);
    panelCenter.add(firstNameLbl, null);
    panelCenter.add(firstNameFld, null);
    panelCenter.add(lastNameLbl, null);
    panelCenter.add(lastNameFld, null);
    panelCenter.add(phoneLbl, null);
    panelCenter.add(phoneFld, null);
    panelCenter.add(addBtn, null);
    panelCenter.add(changeBtn, null);
    panelCenter.add(deleteBtn, null);
    this.getContentPane().add(panelCenter, BorderLayout.CENTER);
   
    firstNameFld.setEditable(false);
    lastNameFld.setEditable(false);
    phoneFld.setEditable(false);
    addBtn.setEnabled(false);
    changeBtn.setEnabled(false);
    deleteBtn.setEnabled(false);
    this.addWindowListener(new WindowAdapter()
      {
        public void windowClosing(WindowEvent e)
        {
          directory.save();
          System.exit(0);
        }
      });
  }

  void fileExit_ActionPerformed(ActionEvent e)
  {
    directory.save();
    System.exit(0);
  }

  private void fileNew_ActionPerformed(ActionEvent e)
  {
    firstNameFld.setText("");
    lastNameFld.setText("");
    phoneFld.setText("");
    firstNameFld.setEditable(true);
    lastNameFld.setEditable(true);
    phoneFld.setEditable(true);
    addBtn.setEnabled(true);
    changeBtn.setEnabled(false);
    deleteBtn.setEnabled(false);
  }

  private void searchFind_ActionPerformed(ActionEvent e)
  {
    String firstname =
      JOptionPane.showInputDialog(this, "Enter first name", "First name",
                                  JOptionPane.QUESTION_MESSAGE);
    String lastname =
      JOptionPane.showInputDialog(this, "Enter last name", "Last name",
                                  JOptionPane.QUESTION_MESSAGE);
    String phoneNumber =
      directory.lookupEntry(firstname, lastname);
    if (phoneNumber != null)
    {
      firstNameFld.setText(firstname);
      lastNameFld.setText(lastname);
      phoneFld.setText(phoneNumber);
      phoneFld.setEditable(true);
      addBtn.setEnabled(false);
      changeBtn.setEnabled(true);
      deleteBtn.setEnabled(true);
    }
    else
      JOptionPane.showMessageDialog(this,
                                    firstname + " " + lastname +
                                    "  is not in your phone directory",
                                    "No such person",
                                    JOptionPane.ERROR_MESSAGE);
  }

  private void addBtn_actionPerformed(ActionEvent e)
  {
    if (firstNameFld.getText().length() == 0)
      JOptionPane.showMessageDialog(this, "First name is missing",
                                    "Missing first name",
                                    JOptionPane.ERROR_MESSAGE);
    else if (lastNameFld.getText().length() == 0)
      JOptionPane.showMessageDialog(this, "Last name is missing",
                                    "Missing last name",
                                    JOptionPane.ERROR_MESSAGE);
    else if (lastNameFld.getText().length() == 0)
      JOptionPane.showMessageDialog(this, "Phone number is missing",
                                    "Phone number last name",
                                    JOptionPane.ERROR_MESSAGE);
    else
    {
      directory.addEntry(firstNameFld.getText(), lastNameFld.getText(),
                         phoneFld.getText());
      JOptionPane.showMessageDialog(this,
                                    firstNameFld.getText() + " " + lastNameFld.getText() +
                                    " has been added", "Person Added",
                                    JOptionPane.INFORMATION_MESSAGE);
      phoneFld.setEditable(true);
      firstNameFld.setEditable(false);
      lastNameFld.setEditable(false);
      addBtn.setEnabled(false);
      changeBtn.setEnabled(true);
      deleteBtn.setEnabled(true);
    }
  } // addBtn_actionPerformed()

  private void changeBtn_actionPerformed(ActionEvent e)
  {
    if (firstNameFld.getText().length() == 0)
      JOptionPane.showMessageDialog(this, "First name is missing",
                                    "Missing first name",
                                    JOptionPane.ERROR_MESSAGE);
    else if (lastNameFld.getText().length() == 0)
      JOptionPane.showMessageDialog(this, "Last name is missing",
                                    "Missing last name",
                                    JOptionPane.ERROR_MESSAGE);
    else if (lastNameFld.getText().length() == 0)
      JOptionPane.showMessageDialog(this, "Phone number is missing",
                                    "Phone number last name",
                                    JOptionPane.ERROR_MESSAGE);
    else if (directory.changeEntry(firstNameFld.getText(),
                                   lastNameFld.getText(),
                                   phoneFld.getText()) != null)
      JOptionPane.showMessageDialog(this,
                                    "Phone number has been changed for " +
                                    firstNameFld.getText() + " " +
                                    lastNameFld.getText(),
                                    "Phone Number Changed",
                                    JOptionPane.INFORMATION_MESSAGE);
    else
      JOptionPane.showMessageDialog(this,
                                    firstNameFld.getText() + " " + lastNameFld.getText() +
                                    "  is not in your phone directory",
                                    "No such person",
                                    JOptionPane.ERROR_MESSAGE);
  }

  private void deleteBtn_actionPerformed(ActionEvent e)
  {
    if (firstNameFld.getText().length() == 0)
      JOptionPane.showMessageDialog(this, "First name is missing",
                                    "Missing first name",
                                    JOptionPane.ERROR_MESSAGE);
    else if (lastNameFld.getText().length() == 0)
      JOptionPane.showMessageDialog(this, "Last name is missing",
                                    "Missing last name",
                                    JOptionPane.ERROR_MESSAGE);
    else
    {
      if (directory.removeEntry(firstNameFld.getText(),
                                lastNameFld.getText()) == null)
        JOptionPane.showMessageDialog(this,
                                      firstNameFld.getText() + " " + lastNameFld.getText() +
                                      "  is not in your phone directory",
                                      "No such person",
                                      JOptionPane.ERROR_MESSAGE);
      else
      {
        JOptionPane.showMessageDialog(this,
                                      firstNameFld.getText() + " " + lastNameFld.getText() +
                                      " has been deleted",
                                      "Person Deleted",
                                      JOptionPane.INFORMATION_MESSAGE);
        firstNameFld.setText("");
        lastNameFld.setText("");
        phoneFld.setText("");
        phoneFld.setEnabled(false);
        changeBtn.setEnabled(false);
        deleteBtn.setEnabled(false);
      }


    }
  }
}
